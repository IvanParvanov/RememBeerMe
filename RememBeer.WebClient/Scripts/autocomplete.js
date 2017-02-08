function pageLoad(sender, args) {
    $("#MainContent_ReviewsListView_TextBox4")
        .autocomplete({
            serviceUrl: "/api/Beers",
            paramName: "name",
            transformResult: function(response) {
                return {
                    suggestions: $.map(
                        JSON.parse(response),
                        function(dataItem) {
                            return {
                                value: dataItem.Name + ", " + dataItem.BreweryName,
                                data: dataItem.Id
                            };
                        })
                };
            },
            onSelect: function(suggestion) {
                $("#MainContent_ReviewsListView_HiddenBeerId").val(suggestion.data);
            }
        });

    $('#createNew').modal('hide');
    $('body').removeClass('modal-open');
    $('.modal-backdrop').remove();
}