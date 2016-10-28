$(function () {
    RegisterIndexLinksToClickEvent()



    //FUNCTIONS
    function RegisterEditSaveClick() {
        $("#bookEditSave").click(function () {
            SaveEdit()
        })
    }

    function SaveEdit() {
        var bookID = $(".editBookID:first").val()
        var title = $(".editTitle:first").val()
        var author = $(".editAuthor:first").val()
        var url = $("#EditBookUrl").val()
        $("#editView").hide(500, function () {
            $.ajax({
                type: 'POST'
                , url: url
                , data: { BookID: bookID, Title: title, Author: author }
                , success: function (response) {
                    $("#indexView").html(response)
                    RegisterIndexLinksToClickEvent()
                }
                , error: function (response) {
                    $("#editView").html(response).show(500)
                }
            })
        })
    }

    function LoadEditPartial(link) {
        var a = link
        $("#editView").hide(500, function () {
            var bookID = a.attr('id')
            var url = $("#EditBookUrl").val()
            $.ajax({
                type: 'GET'
                , url: url
                , data: { BookID: bookID }
                , success: function (response) {
                    $("#editView").html(response)
                    RegisterEditSaveClick()
                    $("#editView").show(500)
                }
            })
        })
    }

    function RegisterIndexLinksToClickEvent() {
        $("a").click(function (event) {
            event.preventDefault()
            var link = $(this)
            LoadEditPartial(link)
        })
    }
})