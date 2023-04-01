import React, { Component } from 'react';

export class GPT extends Component {
  static displayName = GPT.name;
  constructor(props){
    super(props);
    this.state = {question:"",file:"", response:""}
    this.changeQuestion=this.changeQuestion.bind(this);
    this.changeFile=this.changeFile.bind(this);
    this.SendText=this.SendText.bind(this);
    this.SendVoice=this.SendVoice.bind(this);
    this.SendImg=this.SendImg.bind(this);
    this.fileInput = React.createRef();
  }
  changeQuestion(event) {
    this.setState({question: event.target.value});
  }
  changeFile(event) {
    this.setState({file: event.target.files[0]});
  }
  async SendText()
  {
    if(window.sessionStorage.getItem("User")!=null){
        if(this.state.question!==""){
            let response = await fetch('gpt/SendText?text='+this.state.question+"&login="+window.sessionStorage.getItem("User"));
            let result = await response.text();
            this.setState({response: result});
            if(response.status === 200){
              alert(result);
            }
            console.log(result);
        }
        else{
          alert("Write Your Message !")
        }
    }
    else{
        alert("You May Autorise !")
    }
      
  }
  async SendImg(){
    if(window.sessionStorage.getItem("User")!=null){
       if(this.fileInput.current.files[0]!=null){
        let file = this.fileInput.current.files[0];
        var fd = new FormData();
        
        fd.append('file', file);
        // let shmata = JSON.stringify({file:fd, login:window.sessionStorage.getItem("User")});
        // console.log(shmata);
        // console.log(file.name);
        // let data = {
        //     method: 'POST',
        //     body: JSON.stringify({file:fd, login:window.sessionStorage.getItem("User")}),
        //     headers:{
        //       "Accept":"application/json",
        //       "Content-Type":"application/json"
        //     }
            // };
        // console.log(file.name);
        let data = {
            method: 'POST',
            body: fd, 
            headers:{
              "Accept":"application/json"
            }
           };
          let response = await fetch('gpt/DetectImage', data);
          let result = await response.json();
          this.setState({response: result});
          if(response.status === 200){
            alert(result);
          }
          console.log(result);
       }
      else{
        alert("No Chousen Files !")
      }
    }
    else{
      alert("You May Autorise !")
  }
  }
  async SendVoice(){

  }
  render() {
    return (
    <div className='card'>
        <div className="card-body">
            <div className="input-group mb-3">
                <textarea type="text" className="form-control" placeholder="Your Message" aria-label="Your Message" aria-describedby="button-addon2" value={this.state.question} onChange={this.changeQuestion}></textarea>
                <button className="btn btn-outline-primary"onClick={this.SendText}>Send</button>
            </div>
            <div className="input-group mb-3">
                <input type="file" className="form-control" ref={this.fileInput}></input>
                <button className="btn btn-outline-primary" onClick={this.SendImg}>Send Img</button>
            </div>
            {/* <textarea type="text" className="form-control mb-2" placeholder='Your Text' value={this.state.question} onChange={this.changeQuestion}></textarea>
            <button type="button" className="btn btn-primary m-2" onClick={this.SendText}>Send</button> */}
            <button type="button" className="btn btn-danger m-2" onClick={this.SendVoice}>Send Voice</button>
            <h2 className="form-control mb-2">{this.state.response}</h2>
           
        </div>
    </div>
    );
  }
}