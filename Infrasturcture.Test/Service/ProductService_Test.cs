using Infrastructure.Interface;
using Infrastructure.Models;
using Infrastructure.Services;
using Moq;

namespace Infrasturcture.Test.Service;

public class ProductService_Test
{

    [Fact]

    public void AddProductToli_StShouldAddProductToList_ReturnTrue()
    {

        // Arrange
        var fileServiceMock = new Mock<IFileService>();
        var fileService = fileServiceMock.Object;
        fileServiceMock.Setup(fs => fs.SaveContentToFile(It.IsAny<string>()));
 
        var productService = new ProductService(fileService);                 
        var product = new ProductCreateRequest { Id = Guid.NewGuid() ,  Product_Name = "Product1", Product_Price = 155};

        //Act 
       var result =  productService.AddProductToList(product);


        //Assert

        Assert.True(result);
                           


                                   

                                
    }
}
