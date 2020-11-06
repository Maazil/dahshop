import axios from "axios";

export default {
  getItems(context) {
    try {
      axios.get('api/server/items').then(function(response) {
        // check if the response is okay
        
        // const items = [];

        // for(const key in response.data){
        //     const item = {
        //         id: key.id,
        //         ownerId: response.data[key].ownerId,
        //         name: response.data[key].name,
        //         color: response.data[key].color,
        //         size: response.data[key].size,
        //         location: response.data[key].location,
        //         price: response.data[key].price,
        //         description: response.data[key].description,
        //         filePath: response.data[key].filePath
        //     };
        //     items.push(item);
        // }

        context.commit("setItems", response.data);
        console.log("Response: " + JSON.stringify(response.data));
      });
    } catch (error) {
      //   const error = new Error(responseData.message || "Failed to fetch!");
      //   throw error;
      console.log(error);
    }
  },
};
