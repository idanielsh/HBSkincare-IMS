using HBSkincare.Data.Source;
using HBSkincare.Managers;
using HBSkincare.Model;
using System;
using Xunit;

namespace HBSkincareTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IDBContext context = new SQLDBContext();
            RawMaterialItemManager item = new RawMaterialItemManager(context);

            item.UpdateItem(4);

            RawMaterialItem rawMaterialItem = context.SearchRawMaterialItems(4);

            //Assert.True(Math.Round(rawMaterialItem.CostPerUnit, 2) == 0.29);
            //Assert.True(Math.Round(rawMaterialItem.LandedCostPerUnit, 2) == 0.43);


        }
    }
}
