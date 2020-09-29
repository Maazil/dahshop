class clientToServerController{
    constructor() {}


    /**
     * Checks the function type and change the information on the alert based on the input
     * @param {string} funcType What kind of function was executed.
     * @param {object} name Either the name of object or the id.
     * @param {string} model Which database was edited
     */
    changeInfo(funcType, name, model){
        //Changes the div class alert based on the input
        switch (funcType) {
            case "add":
                $(".alert").removeClass("alert-primary alert-danger").addClass("alert-success").css("visibility","visible").text("Added "+ name+" to "+ model);
                break;
            case "edit":
                $(".alert").removeClass("alert-success alert-danger").addClass("alert-primary").css("visibility","visible").text("Edited "+ name+" in "+ model);
                break;
            case "delete":
                $(".alert").removeClass("alert-primary alert-success").addClass("alert-danger").css("visibility","visible").text("Deleted "+ "id "+name+" from "+model);
        }
    }
    
    
    
    /* 
        GET ITEMS FROM SERVER API REQUEST
     */
    
    getItems(self){
        
        //Get request to the serverAPI
        axios.get('api/server/items').then(function(response){
            self.items = response.data;
        });
    }
    
    

    /**
     * Send a post request to the serverAPI and adds the
     response into the item list to be displayed in the frontend.
     * @param {FormData} formdata Contains all the the necessary information about structure
     * @param {object} self The object it belongs to
     */
    
    postItem(formdata, self ){
        
        let client = this;

        //Check if the file is empty and gives warning if empty
        if($('.itemFile').val() == ''){
            return $('.necessaryInfo').text("You must add a valid image file").css('color','red');
        }else {
            $('.necessaryInfo').text("Image files added").css('color','green');
        }

        //Makes a post request to the serverAPI
        axios.post('api/server/items', formdata,
            {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            }).then(function(response){
            console.log("Item successfully added");
            self.items.push(response.data);
            client.changeInfo("add",response.data.name,"items");
            
        }).catch(function(){
            console.log("Something failed");
        });
        
    }// postItem method
    
    
}//clientToServerController Class