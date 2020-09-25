function changeEditMode() {
    var editing = document.getElementById("editMode");
    if (editing.checked) {
        var hiddenItems = document.getElementsByClassName("canBeHidden");
        for (var i = 0; i < hiddenItems.length; i++) {
            hiddenItems[i].style.visibility = 'visible';
        }

        var disabledItems = document.getElementsByClassName("CanBeDisabled");
        for (var i = 0; i < disabledItems.length; i++) {
            disabledItems[i].disabled = false;
        }

        var readonlyItems = document.getElementsByClassName("CanBeReadonly");
        for (var i = 0; i < readonlyItems.length; i++) {
            readonlyItems[i].readOnly = false;
        }
    }
    else {
        var hiddenItems = document.getElementsByClassName("canBeHidden");
        for (var i = 0; i < hiddenItems.length; i++) {
            hiddenItems[i].style.visibility = 'hidden';
        }

        var disabledItems = document.getElementsByClassName("CanBeDisabled");
        for (var i = 0; i < disabledItems.length; i++) {
            disabledItems[i].disabled = true;
        }

        var readonlyItems = document.getElementsByClassName("CanBeReadonly");
        for (var i = 0; i < readonlyItems.length; i++) {
            readonlyItems[i].readOnly = true;
        }
    }
}