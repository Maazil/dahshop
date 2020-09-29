$(document).ready(function () {
    
    let clientToServer = new clientToServerController();

    $('.necessaryInfo').text("(*) = needs to be filled").css('color','black');
    $(".alert").css("visibility","hidden");
    
    // Create vue instance
    var app = new Vue({
        el: '#app',
        data: {
            title: '',
            message: '',
            items: [],
            item: {
                id: 0,
                ownerId: '',
                name: '',
                color: '',
                size: '',
                location: '',
                price: 0,
                description: '',
                files: '',
                filePath: '',
            }


        },

        computed: {},

        watch: {},
        
        created: function() {
            
            /************* Using the get-functions from ClientToServerController **************/
            clientToServer.getItems(this);
        },

        methods: {

            /*************** Call the add-functions from clientToServerController *****************/

            /*
             * Appends the item information to the FormData
             * and calls the postItem function from clientToServerController class
             */

            addItem: function(){
                var self = this;
                // Create a form data
                let formData = new FormData();
                
                for(var i = 0; i < self.item.files.length; i++ ){
                    let file = this.item.files[i];
                    console.log(file);
                    formData.append('files', file);
                }

                formData.append('name',self.item.name);
                console.log("Vue item name: " + self.item.name);
                formData.append("color", self.item.color);
                console.log("Color: " + self.item.color);
                formData.append("size", self.item.size);
                console.log("Size: " + self.item.size);
                formData.append("location", self.item.location);
                console.log(self.item.location);
                formData.append("price", self.item.price);
                console.log(self.item.price);
                formData.append("description", self.item.description);
                formData.append('filePath', self.item.filePath);
                
                console.log("Check data name: " + formData.get("name"));

                clientToServer.postItem(formData, self);
                
            },

            /*********************** File *************************/

            //Checks if it's add or edit then sets the file into the item object
            uploadItemFile: function(){
                let self = this;
                
                // Check if files already exists
                if (self.item.files === ""){
                    // if files is empty set files
                    self.item.files = this.$refs.itemFile.files;
                }else {
                    // Else empty the files first then add the new files
                    self.item.files="";
                    self.item.files = this.$refs.itemFile.files;
                }
            },
            
            
            
            
            

        }//methods
        
        
        
        
        
    }); // vue app
});//document ready
    
    
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
 