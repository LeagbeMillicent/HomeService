//using FluentValidation;
//using HomeService.Application.Exceptions;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HomeService.Application.Behaviours
//{
//    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
//    {

//        private readonly IEnumerable<IValidator<TRequest>> _validators;

//        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
//        {
//            _validators = validators;
//        }
//        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//        {
//            if (_validators.Any())
//            {
//                var context = new ValidationContext<TRequest>(request);

//                try
//                {
//                    var validationresults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
//                    var failures = validationresults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

//                    if (failures.Count != 0)
//                    {
//                        throw new ValidationCommandException(failures);
//                    }
//                }
//                catch (Exception)
//                {

//                    throw;
//                }
//            }

//            return await next();
//        }
//    }
//}
