class clientToServerController{
    constructor() {}

    
    /* 
        GET ITEMS FROM SERVER API REQUEST
     */
    
    getItems(self){
        
        //Get request to the serverAPI
        axios.get('api/server/structures').then(function(response){
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
        if($('.itemFile').val() === ''){
            return $('.necessaryInfo').text("You must add a valid image file").css('color','red');
        }

        //Makes a post request to the serverAPI
        axios.post('/api/server/items', formdata,
            {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            }).then(function(response){
            console.log("Item successfully added");
            self.items.push(response.data);
            //client.changeInfo("add",response.data.name,"structures");
            
        }).catch(function(){
            console.log("Something failed");
        });
        
    }// postItem method
    
    
}//clientToServerController Class