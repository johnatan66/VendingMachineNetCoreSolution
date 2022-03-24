using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineApplication.Business;
using Xunit;
using Moq;
using VendingMachineApplication.Data;
using VendingMachineApplication.Models;

namespace VendingMachineTest
{
    public class VendingMachineBusinessTest
    {
        [Fact]
        public void ShouldStoreMoney_WhenAddingMoney()
        {
            var vm = new VendingMachine
            {
                Id = 1,
                Credits = 50.0
            };

            var handlerMock = new Mock<IVendingMachineHandler>();
            handlerMock.Setup(vmh => vmh.Get(1)).Returns(vm);
            handlerMock.Setup(vmh => vmh.Update(vm)).Returns(vm);

            var vendingMachineBusiness = new VendingMachineBusiness(handlerMock.Object);

            vendingMachineBusiness.AddCredit(1, 10);

            Assert.Equal(60, vm.Credits);
        }

        [Fact]
        public void ShouldNotAllowBuy_WhenMoneyIsNotEnough()
        {
            var p1 = new Product()
            {
                Id = 1,
                Name = "Guarana",
                Value = 2
            };

            var p2 = new Product()
            {
                Id = 2,
                Name = "Mandarin",
                Value = 0.5
            };

            var vm = new VendingMachine
            {
                Id = 1,
                Address = "Test Machine",
                Credits = 0.05,
                Products = new List<Product>()
                {
                    p1, p2
                }
            };

            var handlerMock = new Mock<IVendingMachineHandler>();
            handlerMock.Setup(m => m.Get(1)).Returns(vm);
            handlerMock.Setup(m => m.Update(It.IsAny<VendingMachine>())).Returns(vm);

            var vendingMachineBusiness = new VendingMachineBusiness(handlerMock.Object);

            var product = vendingMachineBusiness.BuyProduct(1, 1);

            Assert.Null(product);
            Assert.Equal(0.05, vm.Credits);
        }

        [Fact]
        public void ShouldReturnProductAndDecreaseCredit_WhenMoneyIsEnough()
        {
            var p1 = new Product()
            {
                Id = 1,
                Name = "Guarana",
                Value = 2,
                Quantity = 10,
            };

            var p2 = new Product()
            {
                Id = 2,
                Name = "Mandarin",
                Value = 0.5,
                Quantity = 10
            };

            var vm = new VendingMachine
            {
                Id = 1,
                Address = "Test Machine",
                Credits = 5.50,
                Products = new List<Product>()
                {
                    p1, p2
                }
            };

            var handlerMock = new Mock<IVendingMachineHandler>();
            handlerMock.Setup(m => m.Get(1)).Returns(vm);
            handlerMock.Setup(m => m.Update(It.IsAny<VendingMachine>())).Returns(vm);

            var vendingMachineBusiness = new VendingMachineBusiness(handlerMock.Object);

            var product = vendingMachineBusiness.BuyProduct(1, 1);

            Assert.NotNull(product);
            Assert.Equal(1, product.Id);
            Assert.Equal(3.50, vm.Credits);
        }

        [Fact]
        public void ShouldReturnProductAndIncreseProductQuantity_WhenRefill()
        {
            var p1 = new Product()
            {
                Id = 1,
                Name = "Guarana",
                Value = 2,
                Quantity = 10,
            };

            var p2 = new Product()
            {
                Id = 2,
                Name = "Mandarin",
                Value = 0.5,
                Quantity = 10
            };

            var vm = new VendingMachine
            {
                Id = 1,
                Address = "Test Machine",
                Credits = 5.50,
                Products = new List<Product>()
                {
                    p1, p2
                }
            };

            var handlerMock = new Mock<IVendingMachineHandler>();
            handlerMock.Setup(m => m.Get(1)).Returns(vm);
            handlerMock.Setup(m => m.Update(It.IsAny<VendingMachine>())).Returns(vm);

            var vendingMachineBusiness = new VendingMachineBusiness(handlerMock.Object);

            var product = vendingMachineBusiness.RefillProducts(1, 1, 10);

            Assert.NotNull(product);
            Assert.Equal(1, product.Id);
            Assert.Equal(20, product.Quantity);
        }  

        [Fact]
        public void ShouldReturnNewVendingMachine_WhenAddNewVendingMachine()
        {
            var p1 = new Product()
            {
                Id = 1,
                Name = "Coca-cola",
                Value = 2,
                Quantity = 10,
            };

            var p2 = new Product()
            {
                Id = 2,
                Name = "Fanta",
                Value = 0.5,
                Quantity = 10
            };

            var vm = new VendingMachine
            {
                Id = 1,
                Address = "Test Machine",
                Credits = 5.50,
                Products = new List<Product>()
                {
                    p1, p2
                }
            };

            var handlerMock = new Mock<IVendingMachineHandler>();
            handlerMock.Setup(m => m.Create(It.IsAny<VendingMachine>()));

            var vendingMachineBusiness = new VendingMachineBusiness(handlerMock.Object);

            var vendingMachine = vendingMachineBusiness.AddVm(vm);

            Assert.NotNull(vendingMachine);
            handlerMock.Verify(m => m.Create(It.IsAny<VendingMachine>()), Times.Once());
        }              
    }
}
