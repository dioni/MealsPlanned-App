using MealsPlanned_App.Model;
using MealsPlanned_App.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MealsPlanned_App.Services
{
    public class RecipeService
    {
        public RecipeViewModel GetRecipe(Guid id)
        {
            RecipeViewModel recipeViewModel = new RecipeViewModel();

            var client = new HttpClientServiceBase<RecipeViewModel>();

            return client.Get(string.Format("api/recipesearch/getbyid?id={0}", id));

            //recipeViewModel.Title = "Massa de panqueca";

            //recipeViewModel.Steps.Add(new MethodOfPreparationViewModel { Step = "1", Description = "Bata todos os ingredientes no liquidificador por 2 minutos" });
            //recipeViewModel.Steps.Add(new MethodOfPreparationViewModel { Step = "2", Description = "Em seguida desligue e, com uma colher, misture a farinha que grudou no copo do liquidificador" });
            //recipeViewModel.Steps.Add(new MethodOfPreparationViewModel { Step = "3", Description = "Bata novamente só para misturar, reserve" });
            //recipeViewModel.Steps.Add(new MethodOfPreparationViewModel { Step = "4", Description = "Unte a frigideira com um fio de óleo e leve ao fogo até aquecer" });
            //recipeViewModel.Steps.Add(new MethodOfPreparationViewModel { Step = "5", Description = "Com o auxílio de uma concha, pegue uma porção de massa e coloque na frigideira, gire a frigideira para espalhar bem a massa" });
            //recipeViewModel.Steps.Add(new MethodOfPreparationViewModel { Step = "6", Description = "Abaixe o fogo e deixe dourar por baixo, em seguida vire do outro lado e deixe dourar, repita o processo com toda a massa" });


            //recipeViewModel.Ingredients.Add(new IngredientViewModel
            //{
            //    ProductName = "Farinha de Trigo",
            //    Observation = "",
            //    UnitName = "xícaras(chá)",
            //    Quantity = 2
            //});

            //recipeViewModel.Ingredients.Add(new IngredientViewModel
            //{
            //    ProductName = "Leite",
            //    Observation = "",
            //    UnitName = "xícaras(chá)",
            //    Quantity = 2
            //});

            //recipeViewModel.Ingredients.Add(new IngredientViewModel
            //{
            //    ProductName = "Ovos",
            //    Observation = "",
            //    UnitName = "unidade",
            //    Quantity = 3
            //});

            //recipeViewModel.Ingredients.Add(new IngredientViewModel
            //{
            //    ProductName = "Sal",
            //    Observation = "",
            //    UnitName = "pitada",
            //    Quantity = 1
            //});

            //return recipeViewModel;
        }

        public IList<RecipeViewModel> Recipes(RecipeSearchQuery query)
        {
            List<RecipeViewModel> recipes = new List<RecipeViewModel>();

            var client = new HttpClientServiceBase<List<RecipeViewModel>>();

            string path = 
                string.Format("api/recipesearch/getbyfilter?keyword={0}&category={1}", 
                query.Keyword, query.Category);

            return client.Get(path);


            //recipes.Add(new RecipeViewModel { Id = Guid.NewGuid(), RecipeTypeName = "Peixes e Frutos do Mar", Title = "Filé de Peixe Assado", RecipeImage = "https://dummyimage.com/500x350/000/fff&text=Peixe" });
            //recipes.Add(new RecipeViewModel { Id = Guid.NewGuid(), RecipeTypeName = "Peixes e Frutos do Mar", Title = "Paella Valenciana", RecipeImage = "https://dummyimage.com/500x350/000/fff&text=Paella" });
            //recipes.Add(new RecipeViewModel { Id = Guid.NewGuid(), RecipeTypeName = "Peixes e Frutos do Mar", Title = "Cação ao Molho Vermelho", RecipeImage = "https://dummyimage.com/500x350/000/fff&text=Cação" });

            //recipes.Add(new RecipeViewModel { Id = Guid.NewGuid(), RecipeTypeName = "Carnes", Title = "BIFE A MILANESA", RecipeImage = "https://dummyimage.com/500x350/000/fff&text=Bife" });
            //recipes.Add(new RecipeViewModel { Id = Guid.NewGuid(), RecipeTypeName = "Carnes", Title = "VACA ATOLADA", RecipeImage = "https://dummyimage.com/500x350/000/fff&text=Vaca" });
            //recipes.Add(new RecipeViewModel { Id = Guid.NewGuid(), RecipeTypeName = "Carnes", Title = "BIFE A ROLÊ", RecipeImage = "https://dummyimage.com/500x350/000/fff&text=BifeARolê" });


            //if (query.Keyword != null)
            //{
            //    recipes = recipes
            //        .Where(x =>
            //        x.Title.Contains(query.Keyword) ||
            //        x.RecipeTypeName.Contains(query.Keyword)).ToList();
            //}

            //return recipes;
        }
    }
}
