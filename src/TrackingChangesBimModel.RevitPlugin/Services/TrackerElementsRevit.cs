namespace TrackingChangesBimModel.RevitPlugin.Services;
internal class TrackerElementsRevit : ITrackerElementsRevitt
{
    public Task<IEnumerable<Element>> GetAllElements(Document document)
    {
        Categories categories = document.Settings.Categories;

        var elementFilters = new List<ElementFilter>();

        foreach (Category category in categories)
        {
            if (category.CategoryType == CategoryType.Model)
                elementFilters.Add(new ElementCategoryFilter(category.Id));
        }

        var modelCategories = new LogicalOrFilter(elementFilters);

        var options = new Options();

        var elementsAfterFiltrations = new FilteredElementCollector(document)
            .WhereElementIsNotElementType()
            .WhereElementIsViewIndependent()
            .WherePasses(modelCategories).Where(x => x is null); //TODO : Поменять апи на 2025 и дописать фильтрацию

        return Task.FromResult(elementsAfterFiltrations);

    }
}
