using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public record PersonData(string Name, int stars);

public class Person : Label {
    public void Init(PersonData data) {
        text = $"{data.Name} ({data.stars} stars)";
    }
}

public class PersonDetail : VisualElement {

    public PersonDetail() {
        AddToClassList("detail");
        Add(label);
        Add(stars);
        stars.RegisterCallback<ChangeEvent<int>>(evt => {
            if (data.stars == evt.newValue) return;
            OnChange.Invoke(data, evt.newValue);
        });
    }

    public event Action<PersonData, int> OnChange = (data, newStarsValue) => { };
    PersonData data;
    Label label = new Label();
    RadioButtonGroup stars = new("Stars", new List<string>() { "0", "1", "2", "3", "4", "5" });

    public void Init(PersonData data) {
        this.data = data;
        label.text = data.Name;
        stars.value = data.stars;
    }

}