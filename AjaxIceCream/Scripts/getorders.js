$(() => {
    
    $("table").on("click", ".edit", function () {
        const button = $(this);
        const row = button.closest('tr');
        const flavor = row.find('td:eq(0)').text();
        $("#flavor").val(flavor);
        
        const data = row.find('td:eq(0)').data();        
        if (data.lowfat) {
            $("#lowfat").prop('checked', true);
        } else {
            $("#lowfat").prop('checked', false);
        }

        const id = $(this).data('id');
        $("#update").data('id', id);

        $(".modal").modal();
    })

    $("table").on("click", ".delete", function () {
        const id = $(this).data('id');        
        $.post("/home/delete", { id: id }, function () {
            resetTable();
        });
    })

    $("#update").on('click', function () {
        console.log("in update");
        const icecream = {
            id: $(this).data('id'),
            flavor: $("#flavor").val(),
            lowfat: ($('#lowfat').is(":checked"))
        }
        $.post("/home/update", icecream, function () {
            $(".modal").modal('hide');
            resetTable();
        });
    })

    
    function resetTable() {
        $(".table tr:gt(0)").remove();
        $.get('/home/getordersajax', function (result) {
            result.forEach(function (ice) {
                let td1;
                if (!ice.LowFat) {
                   td1 = `<tr><td data-lowfat=false>${ice.Flavor}</td>`;                    
                }
                else {
                   td1 = `<tr><td data-lowfat=true>${ice.Flavor} <span class="glyphicon glyphicon-star" aria-hidden="true"></span> </td>`;
                }
                console.log(td1);
                $(".table").append(`${td1}<td><button data-id="${ice.Id}" class="btn btn-warning edit">Edit</button>` +
                    `&nbsp; <button data-id="${ice.Id}" class="btn btn-danger delete">Delete</button></td></tr>`
                );
            });
        }) 
    }

});

