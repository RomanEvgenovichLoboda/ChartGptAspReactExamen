import React, { Component } from 'react';

export class Autorisation extends Component {
  static displayName = Autorisation.name;
  constructor(props){
    super(props);
    this.state = {login:"",password:""}
    this.changeLogin=this.changeLogin.bind(this);
    this.changePassword=this.changePassword.bind(this);
    this.Registr=this.Registr.bind(this);
    this.Autoris=this.Autoris.bind(this);
  }
  changePassword(event) {
    this.setState({password: event.target.value});
  }
  changeLogin(event) {
    this.setState({login: event.target.value});
  }
  async Registr() {
    let data = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            login: this.state.login,
            password: this.state.password
            })
        };
      let response = await fetch('user/Registration', data);
      let result = await response.json();
      console.log(result);
}
async Autoris() {
    let data = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            login: this.state.login,
            password: this.state.password
            })
        };
      let response = await fetch('user/Autorisation', data);
      let result = await response.json();
      console.log(result);
      if(response.status===200){
        window.sessionStorage.setItem("User",result.login);
        window.sessionStorage.setItem("Subscribe",result.subscription);
        let user = window.sessionStorage.getItem("User");
        let subscribe  = window.sessionStorage.getItem("Subscribe");
        //alert(user+subscribe);
        window.location.href='/chat';
      }
}
  render() {
    
    return (
    <div className='card'>
        <div className="card-body">
        <input type="text" className="form-control mb-2" placeholder='Login' onChange={this.changeLogin}></input>
        <input type="text" className="form-control mb-2" placeholder='Password' onChange={this.changePassword}></input>
        <button type="button" className="btn btn-primary" onClick={this.Autoris}>Autorisation</button>
        <button type="button" className="btn btn-warning" onClick={this.Registr}>Registration</button>
        </div>
    </div>
    );
  }
}