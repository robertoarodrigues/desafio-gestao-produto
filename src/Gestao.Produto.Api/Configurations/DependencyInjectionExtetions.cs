using Gestao.Produto.Application.Interface;
using Gestao.Produto.Application.Services;
using Gestao.Produto.Core.Communication.Mediator;
using Gestao.Produto.Core.Messages.Notifications;
using Gestao.Produto.Data.Repository;
using Gestao.Produto.Domain.Commands;
using Gestao.Produto.Domain.Interface;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Gestao.Produto.Api.Configurations
{
    public static class DependencyInjectionExtetions
    {
        public static IServiceCollection AddDependencyGroup(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Command
            services.AddScoped<IRequestHandler<CadastrarProdutoCommand, bool>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarProdutoCommand, bool>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverProdutoCommand, bool>, ProdutoCommandHandler>();

            //Services
            services.AddScoped<IProdutoService, ProdutoService>();

            //Repositories
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
