using MobileApp.API;
using MobileApp.Models;
using MobileApp.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace MobileApp.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CatalogDataService
    {
        #region fields

        private static CatalogDataService catalogDataService;

        private CatalogPageViewModel catalogPageViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance for the <see cref="CatalogDataService"/> class.
        /// </summary>
        private CatalogDataService()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="CatalogDataService"/>.
        /// </summary>
        public static CatalogDataService Instance => catalogDataService ?? (catalogDataService = new CatalogDataService());

        /// <summary>
        /// Gets or sets the value of catalog page view model.
        /// </summary>
        public CatalogPageViewModel CatalogPageViewModel =>
            this.catalogPageViewModel ??
            (this.catalogPageViewModel = PopulateData("catalogs.json"));

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static CatalogPageViewModel PopulateData(string fileName)
        {
            var file = "MobileApp.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            List<Catalog> catalogs = new List<Catalog>();

  
            if (catalogs?.Count > 0)
            {
                File.WriteAllText(file, JsonConvert.SerializeObject(catalogs));
            }
            else
            {
                using (var stream = assembly.GetManifestResourceStream(file))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string jsonFile = reader.ReadToEnd(); //Make string equal to full file
                        catalogs = JsonConvert.DeserializeObject<List<Catalog>>(jsonFile);
                    }      
                }
            }

            CatalogPageViewModel catalogPageViewModel = new CatalogPageViewModel();
            catalogPageViewModel.Catalogs = new ObservableCollection<Catalog>(catalogs); ;

            return catalogPageViewModel;
        }

        #endregion
    }
}