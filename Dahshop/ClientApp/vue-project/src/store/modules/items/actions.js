import axios from "axios";

export default {
  getItems(context) {
    try {
      axios.get("api/server/items").then(function(response) {
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
