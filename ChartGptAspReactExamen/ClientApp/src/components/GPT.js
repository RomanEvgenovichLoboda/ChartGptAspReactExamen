import React, { Component } from 'react';

export class GPT extends Component {
  static displayName = GPT.name;
  constructor(props){
    super(props);
    this.state = {question:"", response:""}
    this.changeQuestion=this.changeQuestion.bind(this);
    this.SendText=this.SendText.bind(this);
    this.SendVoice=this.SendVoice.bind(this);
    this.SendImg=this.SendImg.bind(this);
  }
  changeQuestion(event) {
    this.setState({question: event.target.value});
  }
  async SendText()
  {
    if(window.sessionStorage.getItem("User")!=null){
        if(this.state.question!=""){
            let response = await fetch('gpt/SendText?text='+this.state.question);
            let result = await response.text();
            this.setState({response: result});
            console.log(result);
        }
    }
    else{
        alert("You May Autorise !")
    }
      
  }
  async SendImg(){
    
  }
  async SendVoice(){

  }
  render() {
    return (
    <div className='card'>
        <div className="card-body">
            <div class="input-group mb-3">
                <textarea type="text" class="form-control" placeholder="Your Message" aria-label="Your Message" aria-describedby="button-addon2" value={this.state.question} onChange={this.changeQuestion}></textarea>
                <button class="btn btn-outline-primary"onClick={this.SendText}>Send</button>
            </div>
            <div class="input-group mb-3">
                <input type="file" class="form-control" placeholder="Your Message" aria-label="Your Message" aria-describedby="button-addon2"></input>
                <button class="btn btn-outline-primary" onClick={this.SendImg}>Send</button>
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