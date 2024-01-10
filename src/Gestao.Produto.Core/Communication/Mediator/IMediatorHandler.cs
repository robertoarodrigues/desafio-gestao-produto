using Gestao.Produto.Core.Messages.Notifications;
using System.Threading.Tasks;

namespace Gestao.Produto.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
    }
}
