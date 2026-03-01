using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using DWFSWPFUserInterface.EventModels;

namespace DWFSWPFUserInterface.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM,
            SimpleContainer container)
        {
            _events = events;
            _salesVM = salesVM;
            _container = container;

            _events.SubscribeOnPublishedThread(this);

            ActivateItemAsync(_container.GetInstance<LoginViewModel>());
        }

        //public task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        //{
        //    ActivateItemAsync(_salesVM, cancellationToken);
        //}


        //public void Handle(LogOnEvent message)
        //{
        //    ActivateItemAsync(_salesVM);
        //}
        Task IHandle<LogOnEvent>.HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            ActivateItemAsync(_salesVM);
            return Task.CompletedTask;
        }

        
    }
}
