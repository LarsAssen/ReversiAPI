class FeedbackWidget{
    constructor(elementId) {
       this._elementId = elementId;
       this.feedback_widget_history = [];
     }

     get elementId() { //getter, set keyword voor setter methode
         return this._elementId;
       }
   
       show(message, type){
        //code
          var x = document.getElementById(this._elementId);

           if (x.style.display === "none") {
             x.style.display = "block";
             if(type == "success"){
               $(x).addClass('alert-success');
             }
             if(type == "danger"){
               $(x).addClass('alert-danger');
             }
             $(x).html("<p>"+ message +"</p>");

             let item = {
               type: type,
               message: message
             }
             this.log(item);
           } 
       }
   
       hide(){
         var x = document.getElementById(this._elementId);
           x.style.display = "none";
       }
       log(message){
        this.feedback_widget_history.push(message);
        if(this.feedback_widget_history.length > 10){
          this.removelog();
        }
        localStorage.setItem('feedback_widget_history', JSON.stringify(this.feedback_widget_history));
       }

       removelog(){
         this.feedback_widget_history.shift();
       }

       clearStorage(){
         localStorage.clear();
       }

       history(){
         var item = JSON.parse(localStorage.getItem('feedback_widget_history'));
         console.log(item);         
         for(let i = 0; i < item.length; i++){
           console.log("<type |" + item[i].type + "|> - <" + item[i].message + ">");
         }
       }
   }