// Vue app
$(document).ready(function () {

    new Vue({
        el: '#app',
        data:{
            title: 'Hello World!',
            link : 'http://google.com',
            finishedLink: '<a href="http://google.com">Google</a> ',
            imageLink : 'https://img.webmd.com/dtmcms/live/webmd/consumer_assets/site_images/article_thumbnails/video/how_to_figure_dogs_age_video/1800x1200_how_to_figure_dogs_age_video.jpg?resize=750px:*',
            name : 'Matthew',
            age : '21',
            counter : 0,
            x : 0,
            y : 0,
            value : '',
            newVal : 0,
            result : '',
        },
        
        computed: {
          output: function () {
              return this.newVal === 12 ? 'Done' : 'Not there yet';
          }  
        },

        watch: {
            // the output has to refer to the computed property in order to work
            output: function () {
                var vm = this;
                setTimeout(function () {
                    vm.newVal = 0;
                },5000);

            }
        },
        
        methods: {
            
            sayHello : function () {
               this.title = 'Hello!';
                return this.title;
            },
            
            generateRN : function () {
                return Math.random();
            },
            
            increase : function (step, event) {
                this.counter += step;
            },
            
            updateCoordinates : function (event) {
                this.x = event.clientX;
                this.y = event.clientY;
            },
            
            alert : function () {
                alert("Alert");
            },
            
            store : function (event) {
              this.value = event.target.value;  
            }
            
        }
        
    }); // Vue app
    
    
    
}); // document ready