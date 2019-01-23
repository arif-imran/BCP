using System.Threading.Tasks;
using BCP.Forms.ViewModels;
using Xunit;
using BCP.Facade.Facades;
using Microsoft.Practices.Unity;
using Prism.Navigation;
using Moq;
namespace BCP.UnitTest.Tests
{
    public class PdfViewerPageViewModel_Test :ViewModelTestsBase
    {
        PdfViewerPageViewModel vm;
        [Fact]
        public async Task PdfViewerPage_DocumentLoaded(){
			//Arrrange
            var documentFacade = Mock.Get(this.container.Resolve<IDocumentFacade>());
            documentFacade.Setup(x=>x.GetBCPDocument("Url")).ReturnsAsync(new byte[]{});
            this.vm = new PdfViewerPageViewModel(
                dialogService: this.DialogService.Object,
                authenticationFacade: AuthenticationFacade.Object,
                documentFacade: documentFacade.Object
			);
			//Act
			NavigationParameters navParam = new NavigationParameters();
			navParam.Add("Title", "Title");
            navParam.Add("Url", "Url");
			this.vm.OnNavigatedTo(navParam);
			await Task.Delay(1000);
			//Assert
            documentFacade.Verify(x => x.GetBCPDocument("Url"), Times.Once());
            Assert.Equal(this.vm.DocumentBytes,new byte[]{});
        }
    }
}
