$(() => {
    $("#add").on('click', function () {
        const flavor = $("#flavor").val();
        const lowfat = ($('#lowfat').is(":checked"));        
        const iceCream = {
            flavor,
            lowfat
        }
        $("#flavor").val("");
        $("#lowfat").prop('checked', false);
        $("#msg").empty();
        $("#msg").append(flavor + ' ice cream has been added');        
    $.post("/home/add", iceCream);    
    })

});