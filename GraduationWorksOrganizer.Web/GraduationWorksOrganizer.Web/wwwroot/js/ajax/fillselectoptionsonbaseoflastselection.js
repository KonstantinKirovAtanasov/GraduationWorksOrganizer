$(document).ready(function () {
    let items = document.getElementsByClassName("load");
    for (let i = 0; i < items.length; i++) {
        let item = items[i];
        item.addEventListener('change', function () {
            RemoveDefaultOption(item.id);
            const $itemSourceSelectId = $(item).attr('data-ajax-loadelementId');
            let itemForLoad = document.getElementById($itemSourceSelectId);
            const $apiEndPoint = $(itemForLoad).attr('data-axaj-load');
            const selectedItemId = item.options[item.selectedIndex].value;
            requestSelectOptions($apiEndPoint, itemForLoad.id, selectedItemId);
            MakeSelectDisabledIfEmpty(item);
        })
        MakeSelectDisabledIfEmpty(item);
    }

    function requestSelectOptions(apiEndPoint, itemForLoadId, selectedId) {
        const apiRoute = 'https://localhost:44306/api/UnivercityItems/';
        $.ajax({
            url: apiRoute + apiEndPoint + '/' + selectedId,
            success: function (result) {
                AddSelectOptions(result, itemForLoadId)
            },
            error: function (error) { console.log(error) }
        })
    }

    function AddSelectOptions(ajaxResult, itemForLoadId) {
        let itemForLoad = $('#' + itemForLoadId);
        $(itemForLoad).empty();
        AddDefaultOption(itemForLoad);
        $.each(ajaxResult, function (index, value) {
            itemForLoad.append('<option value="' + value.id + '">' + value.name + '</option>');
        });
        MakeSelectDisabledIfEmpty(itemForLoad);
    }

    function MakeSelectDisabledIfEmpty(selectItem) {
        console.log($(selectItem).length);
        if ($(selectItem).length === 0) {
            $(selectItem).prop('disabled', true);
            AddDefaultOption(selectItem);
        }
    }

    function RemoveDefaultOption(itemId) {
        let options = $('#' + itemId + '>option');
        for (let i = 0; i < options.length; i++) {
            if (options[i].value === 'default') {
                options[i].remove();
            }
        }
    }

    function AddDefaultOption(itemForLoad) {
        itemForLoad.append('<option value="default" selected="selected" >Моля изберете</option>');
    }
})