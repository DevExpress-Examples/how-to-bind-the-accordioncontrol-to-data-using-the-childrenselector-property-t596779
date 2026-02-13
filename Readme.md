<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128640215/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T596779)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Accordion Control - Bind to a Data Source that Contains Hierarchical Data Objects of Different Types

This example binds the WPF [`AccordionControl`](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl) to a hierarchical data structure that includes objects of different types. Use this technique when your data model does not expose a unified child collection (for instance, when parent and child objects do not share a common base class).

The implementation leverages the [`ChildrenSelector`](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenSelector) property to retrieve child items at runtime. The standard [`ChildrenPath`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenPath) property cannot traverse mixed-type hierarchies. The [`ChildrenSelector`](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenSelector) property delegates child resolution to your custom logic.

## Implementation Details

### Data Structure

The [`AccordionControl`](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl) binds to a flat list of `Category` objects. Each `Category` contains a collection of `Item` objects in its `Items` property.

```csharp
public class Category {
    public string CategoryName { get; set; }
    public ObservableCollection<Item> Items { get; set; }
}

public class Item {
    public string ItemName { get; set; }
}
```

### Custom Children Selector

The custom selector (`MySelector`) implements the `IChildrenSelector` interface. The selector returns child items only for `Category` objects:

```csharp
public class MySelector : IChildrenSelector {
    public IEnumerable SelectChildren(object item) {
        if (item is Category category)
            return category.Items;
        return null;
    }
}
```

### XAML Configuration

Register the selector as a resource and assign it to the [`AccordionControl.ChildrenSelector`](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenSelector) property:

```xaml
<local:MySelector x:Key="mySelector" />
<dxa:AccordionControl
    ItemsSource="{Binding MyData.Categories}"
    ChildrenSelector="{StaticResource mySelector}" />
```

### Data Templates

Define templates to display `Category` and `Item` objects:

```xaml
<DataTemplate DataType="{x:Type local:Category}">
    <TextBlock Text="{Binding CategoryName}" />
</DataTemplate>
<DataTemplate DataType="{x:Type local:Item}">
    <TextBlock Text="{Binding ItemName}" />
</DataTemplate>
```

## Files to Review

* [MainWindow.xaml](./CS/ChildrenSelector/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/ChildrenSelector/MainWindow.xaml))
* [ViewModel.cs](./CS/ChildrenSelector/ViewModel.cs) (VB: [ViewModel.vb](./VB/ChildrenSelector/ViewModel.vb))

## Documentation

* [AccordionControl](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control)
* [AccordionItem](https://docs.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionItem)
* [AccordionViewMode](https://docs.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionViewMode)
* [AccordionControl.ChildrenSelector](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenSelector)
* [Data Binding](https://documentation.devexpress.com/WPF/118635/Controls-and-Libraries/Navigation-Controls/Accordion-Control/Data-Binding)
* [MVVM Framework](https://docs.devexpress.com/WPF/15112/mvvm-framework)

## More Examples

* [ WPF Accordion Control - Bind to Hierarchical Data Structure](https://github.com/DevExpress-Examples/wpf-accordion-bind-to-hierarchical-data-structure)
* [WPF MVVM Framework - Use View Models Generated at Compile Time](https://github.com/DevExpress-Examples/wpf-mvvm-framework-view-model-generator)
* [WPF Dock Layout Manager - Bind the View Model Collection with LayoutAdapters](https://github.com/DevExpress-Examples/wpf-docklayoutmanager-bind-view-model-collection-with-layoutadapters)
* [WPF Dock Layout Manager - Bind the View Model Collection with IMVVMDockingProperties](https://github.com/DevExpress-Examples/wpf-docklayoutmanager-bind-view-model-collection-with-IMVVMDockingProperties)
* [WPF Dock Layout Manager - Populate a DockLayoutManager LayoutGroup with the ViewModels Collection](https://github.com/DevExpress-Examples/wpf-docklayoutmanager-display-viewmodels-collection-in-layoutgroup)

<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-accordion-bind-to-hierarchical-objects-of-different-types&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-accordion-bind-to-hierarchical-objects-of-different-types&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->


