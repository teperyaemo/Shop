using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.mocks
{
    public class MockDetails : IAllDetails
    {
        private readonly IDetailsCategory _categoryDetails = new MockCategory();

        public IEnumerable<Detail> Details
        {
            get
            {
                return new List<Detail>
                {
                    new Detail 
                    { 
                        detailName = "колесная пара б/у", 
                        model = "", 
                        gost="",
                        description = "", 
                        drawingNumber= "", 
                        visible= true, 
                        Category = _categoryDetails.AllCategories.First() 
                    },
                };
            }
        }
        public IEnumerable<Detail> getVisibleDetails { get; set ; }

        public Detail getObjectDetail(int detailId)
        {
            throw new NotImplementedException();
        }
    }
}
