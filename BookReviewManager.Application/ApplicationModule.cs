using BookReviewManager.Application.Commands.BookCommands.AddReview;
using BookReviewManager.Application.Commands.BookCommands.CreateBook;
using BookReviewManager.Application.Commands.BookCommands.UpdateBookCover;
using BookReviewManager.Application.Commands.UserCommands.CreateUser;
using BookReviewManager.Application.Commands.UserCommands.DeleteUsers;
using BookReviewManager.Application.Commands.UserCommands.UpdateUser;
using BookReviewManager.Application.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookReviewManager.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddHandlers()
                .AddValidators();
            return services;
        }


        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<CreateBookCommand>());
            services.AddTransient<IPipelineBehavior<CreateBookCommand, ResultVM<int>>,ValidateCreateBookCommandBehavior>();
            services.AddTransient<IPipelineBehavior<UpdateBookCoverCommand, ResultVM>,ValidateUpdateBookCoverCommandBehavior>();
            services.AddTransient<IPipelineBehavior<CreateUserCommand, ResultVM<int>>,ValidateCreateUserCommandBehavior>();
            services.AddTransient<IPipelineBehavior<AddReviewCommand, ResultVM<int>>,ValidateAddReviewCommandBehavior>();
            services.AddTransient<IPipelineBehavior<UpdateUserCommand, ResultVM>, ValidateUpdateUserCommandBehavior>();
            services.AddTransient<IPipelineBehavior<DeleteUserCommand, ResultVM>,ValidateDeleteUserCommandBehavior>();
            return services;
        }
        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateBookCommand>();
            return services;
        }
    }
}
