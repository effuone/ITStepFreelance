using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStepFreelanceApp.Domain.Core.Models {
  public abstract class BaseEntity {
    private List<IDomainEvent> _domainEvents;
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent) {
      _domainEvents = _domainEvents ?? new List<IDomainEvent>();
      this._domainEvents.Add(domainEvent);
    }
    public void ClearDomainEvents() {
      _domainEvents?.Clear();
    }
  }
}
