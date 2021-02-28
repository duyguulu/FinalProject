using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect' tir: yani metodun basında sonunda calısacak yapı
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding = savunma kodu, burası olmasa da kod calısır fakat isteyen istediği değişkeni verir. bu da programın hatalı çalışamsına sebebiyet verebilir
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //gönderilen type bir IValidator mü değil mi? değilse bir exception gönder.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //calısma anında bir instance oluşturmayı sağlar
            //aynı Product p = new Product() gibi => CreateInstance
            //IValidator=productvalidator
            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            //burada productvalidatorun Base'ine git(base'i implement ettiği class=AbstractValidator)
            // baseindeki <...> içinde giden tiplerden 0. sını yakala ve onun tipini entityType'ın içine at.
            //entityType= product
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            //metodun(invocation= örneğin : Add() metodu) Argümanlarını(parametrelerini) gez.
            //public IResult Add(Product product) idi. producttype ile entitieslerden uyuşan varsa örneğin burada Product bunları validate et demek. kontrol et.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
