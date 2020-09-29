$(document).ready(function () {
    
    // Get all items from database and create divs and forms for each item
    let client2Server = new clientToServerController();
    
    let app = new Vue({
        el: '#content',
        data: {
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
        
        created: function () {
            client2Server.getItems(this);
        },
        
        methods: {
            
            postItemsInDivs: function () {
                
                let getFiles = this.items;
                
                for (var i = 0; i < getFiles.length; i++){
                    console.log("There are: " + i + " files");


                    let createDiv = document.createElement("div");
                    createDiv.className = "row";

                    createDiv.innerHTML = "<p> Hello test! </p>";
                }
                
                
                let itemDiv = document.createElement("div");
                itemDiv.className = "col border border-success";
                itemDiv.innerHTML = "<li> List one </li>";
                
                
            }
        },
        
        
        
    });
        
    

});
    
