$(document).ready(function () {
    
    let clientToServer = new clientToServerController();     
    // Create vue instance
    var app = new Vue({
        el: '#app',
        data: {
            title: '',
            message: '',
            items: [],
            item: {
                id: 0,
                ownerId: 0,
                files: '',
                filePath: '',
                name: '',
                description: '',
                size: '',
                location: '',
                color: '',
                price: 0,
            },


        },

        computed: {},

        watch: {},

        methods: {

            /*************** Call the add-functions from clientToServerController *****************/

            /**
             * Appends the item information to the FormData
             * and calls the postItem function from clientToServerController class
             */

            addItem: function (event) {
                let self = this;
                
                // Create a form data
                let formData = new FormData();


                for(let i = 0; i < self.item.files.length; i++ ){
                    let file = this.item.files[i];
                    console.log(file);
                    formData.append('files', file);
                }

                formData.append('name',self.item.name);
                formData.append('filePath',self.item.filePath);
                clientToServer.postItem(formData, self);
                
                //self.items.files = this.$refs.items.files;

            }

        }
    });

});
    
    
/*
window.onload = function() {

    //Check File API support
    if (window.File && window.FileList && window.FileReader) {
        var filesInput = document.getElementById("files");
        filesInput.addEventListener("change", function (event) {

            var files = event.target.files; //FileList object
            var output = document.getElementById("result");

            for (var i = 0; i < files.length; i++) {
                var file = files[i];

                //Only pics
                if (!file.type.match('image'))
                    continue;
                var picReader = new FileReader();

                picReader.addEventListener("load", function (event) {
                    var picFile = event.target;
                    var div = document.createElement("div");
                    div.innerHTML =
                        "<img class='thumbnail' src='" + picFile.result + "'" + "title='preview image' />";
                    output.insertBefore(div, null);
                });

                //Read the image
                $('#clear, #result').show();
                picReader.readAsDataURL(file);
            }
        });
    } else {
        console.log("Your browser does not support File API");
    }


    $('#files').addEventListener("click", function (event) {
        $('.thumbnail').parent().remove();
        $('result').hide();
        $(this).val("");
    });

    $('#clear').addEventListener("click", function (event) {
        $('.thumbnail').parent().remove();
        $('#result').hide();
        $('#files').val("");
        $(this).hide();
    });


};

*/
 