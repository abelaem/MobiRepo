using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using MovieHub.ViewModels;

namespace MovieHub.Services
{
    public interface IProductServices
    {
        #region Public Methods

        ProductsViewModel GenerateModel();

        ProductViewModel GenerateModelForCreate();

        IEnumerable<Product> GetListName(string search);

        #endregion Public Methods
    }

    public class ProducService : IProductServices
    {
        #region Private Fields

        private IProducsCategoryService _producsCategoryService;
        private IMobiRepository<Product> _Repository;
        private IUOMService _uomService;

        #endregion Private Fields

        #region Public Constructors

        public ProducService(IProducsCategoryService producsCategoryService, IUOMService uomService, IMobiRepository<Product> mobiRepository)
        {
            _producsCategoryService = producsCategoryService;
            _uomService = uomService;
            _Repository = mobiRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public ProductsViewModel GenerateModel()
        {
            ProductsViewModel productViewModel = new ProductsViewModel();
            productViewModel.Products = _Repository.GetAll();
            productViewModel.ProducsCategories = _producsCategoryService.GetCategoryList();
            productViewModel.UOMs = _uomService.GetList();
            return productViewModel;
        }

        public ProductViewModel GenerateModelForCreate()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.ProducsCategories = _producsCategoryService.GetCategoryList();
            productViewModel.UOMs = _uomService.GetList();

            return productViewModel;
        }

        #endregion Public Methods

        //public ProductViewModel GetProductViewModelById()
        //{
        //   productViewModel.ProducsCategories = _producsCategoryService.GetCategoryList();
        //   productViewModel.UOMs = _uomService.GetList();

        // }

        public  IEnumerable<Product> GetListName(string search)
        {
            return _Repository.FindBy(s => s.Name.Contains(search));
        }
    }
}
