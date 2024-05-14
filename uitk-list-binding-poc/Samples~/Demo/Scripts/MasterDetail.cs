using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MasterDetail : VisualElement {



    public MasterDetail() {
        styleSheets.Add(Resources.Load<StyleSheet>("styles"));
        AddToClassList("master");

        var dataSource = createList();

        Func<VisualElement> makeItem = () => new Person();
        Action<VisualElement, int> bindItem = (e, i) => (e as Person).Init(dataSource[i]);

        var detail = new PersonDetail();
        detail.AddToClassList("hidden");

        var listView = new ListView {
            makeItem = makeItem,
            bindItem = bindItem,
            itemsSource = dataSource,
            selectionType = SelectionType.Multiple
        };
        listView.AddToClassList("list");


        listView.selectionChanged += (e) => {
            var data = e.First() as PersonData;
            Debug.Log($"on list change {e}");
            detail.Init(data);
            detail.RemoveFromClassList("hidden");
        };

        detail.OnChange += (d, i) => {
            var index = dataSource.IndexOf(d);
            Debug.Log($"on details change {d}, {i}, {index}");
            dataSource[index] = d with { stars = i };
            listView.RefreshItem(index);
            // re-init the detail with the new ref
            detail.Init(dataSource[index]);
        };


        var listHeading = new Label { text = "List:" };
        listHeading.AddToClassList("heading");
        var detailHeading = new Label { text = "Detail:" };
        detailHeading.AddToClassList("heading");

        Add(listHeading);
        Add(listView);
        Add(detailHeading);
        Add(detail);
    }

    List<PersonData> createList() {
        const int itemCount = 20;
        var items = new List<PersonData>(itemCount);
        for (int i = 1; i <= itemCount; i++)
            items.Add(new PersonData("Person" + i, UnityEngine.Random.Range(0, 6)));
        return items;
    }

}
