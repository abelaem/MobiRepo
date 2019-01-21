using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using Domain.Interfaces;

namespace MovieHub.Services
{
    public interface IPartnerService
    {
        IEnumerable<Partner> GetList();
        IEnumerable<Partner> GetListBy(int PartnerId);
        void AddPartner(Partner partner);
        void RemovePartner(Partner partner);
        void EditPartner(Partner partner);
        IEnumerable<Partner> GetListBy(string SearchText);
      
    }
    public class PartnerService : IPartnerService
    {
        private readonly IMobiRepository<Partner> _Repository;

        public PartnerService(IMobiRepository<Partner> mobiRepository)
        {
            _Repository = mobiRepository;
        }

        public void AddPartner(Partner partner)
        {
            _Repository.Add(partner);
            _Repository.Save();
        }

        public void EditPartner(Partner partner)
        {
            _Repository.Edit(partner);
            _Repository.Save();
        }

        public IEnumerable<Partner> GetList()
        {
            return _Repository.GetAll();
        }

        public IEnumerable<Partner> GetListBy(int PartnerId)
        {
            return _Repository.FindBy(s => s.Id == PartnerId);
        }

        public IEnumerable<Partner> GetListBy(string SearchText)
        {
            return _Repository.FindBy(s => s.Name == SearchText);

        }

        public void RemovePartner(Partner partner)
        {
            _Repository.Delete(partner);
            _Repository.Save();
        }
    }
}