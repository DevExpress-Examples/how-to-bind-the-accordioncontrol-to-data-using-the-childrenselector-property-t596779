<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128640215/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T596779)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Accordion Control - Bind to data through the ChildrenSelector property

This example binds the [AccordionControl](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.class) to data using the [AccordionControl.ChildrenSelector](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenSelector.property) property.

Refer to the [Data Binding](https://documentation.devexpress.com/WPF/118635/Controls-and-Libraries/Navigation-Controls/Accordion-Control/Data-Binding) topic for more information.

## Implementation details

In this example, the [AccordionControl](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control) is bound to a flat list of `Category` objects. Each `Category` stores a collection of `Item` objects in its `Items` property.

To build a hierarchical view from the flat structure, the [AccordionControl](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control) uses the [`ChildrenSelector`](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenSelector.property) property. This property is set to a custom implementation of the `IChildrenSelector` interface:

```csharp
public class MySelector : IChildrenSelector {
    public IEnumerable SelectChildren(object item) {
        if (item is Category)
            return ((Category)item).Items;
        return null;
    }
}
```

In XAML, the selector is declared as a static resource and assigned to the [AccordionControl.ChildrenSelector](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenSelector.property) property:

```xaml
<local:MySelector x:Key="mySelector" />

<dxa:AccordionControl
    ItemsSource="{Binding MyData.Categories}"
    ChildrenSelector="{StaticResource mySelector}" />
```

The [AccordionControl](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control) uses data templates to display `Category` and `Item` objects:

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

- [AccordionControl](https://docs.devexpress.com/WPF/118347/controls-and-libraries/navigation-controls/accordion-control)
- [AccordionItem](https://docs.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionItem)
- [AccordionViewMode](https://docs.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionViewMode)
- [AccordionControl.ChildrenSelector](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Accordion.AccordionControl.ChildrenSelector.property)
- [Data Binding](https://documentation.devexpress.com/WPF/118635/Controls-and-Libraries/Navigation-Controls/Accordion-Control/Data-Binding)
- [MVVM Framework](https://docs.devexpress.com/WPF/15112/mvvm-framework)

## More Examples
- [ WPF Accordion Control - Bind to Hierarchical Data Structure](https://github.com/DevExpress-Examples/wpf-accordion-bind-to-hierarchical-data-structure)
- [WPF MVVM Framework - Use View Models Generated at Compile Time](https://github.com/DevExpress-Examples/wpf-mvvm-framework-view-model-generator)
- [WPF Dock Layout Manager - Bind the View Model Collection with LayoutAdapters](https://github.com/DevExpress-Examples/wpf-docklayoutmanager-bind-view-model-collection-with-layoutadapters)
- [WPF Dock Layout Manager - Bind the View Model Collection with IMVVMDockingProperties](https://github.com/DevExpress-Examples/wpf-docklayoutmanager-bind-view-model-collection-with-IMVVMDockingProperties)
- [WPF Dock Layout Manager - Populate a DockLayoutManager LayoutGroup with the ViewModels Collection](https://github.com/DevExpress-Examples/wpf-docklayoutmanager-display-viewmodels-collection-in-layoutgroup)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-bind-the-accordioncontrol-to-data-using-the-childrenselector-property-t596779&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-bind-the-accordioncontrol-to-data-using-the-childrenselector-property-t596779&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
