import React, {Component} from "react";
import './login.css';

import Axios from 'axios';
import { thisExpression } from "@babel/types";
import {Link} from "react-router-dom";
export default class Login extends Component {

    constructor (){
        super();
        this.state = {
            email:"",
            senha:"",
            erro:""
        }
    }

    mudarEstadoEmail = (event) =>{
        this.setState({email: event.target.value})
    }

    mudarEstadoSenha = (event) => {
        this.setState({senha: event.target.value})
    }

    efetuarLogin =(event) =>{
        event.preventDefault();

        Axios.post("http://192.168.5.84:5000/api/Login",{
            email: this.state.email,
            senha: this.state.senha
        })
         .then (data =>{
             if(data.status === 200){
                 localStorage.setItem("usuario-opflix", data.data.token);
                 this.props.history.push('/homeA');
             }else{
                 console.log("erro")
             }
         })
         .catch(erro =>{
            this.setState({erro: "Usúario com senha ou email inválidos"});
            console.log(erro);
         })
    }

    render(){
        return(
            <div className="login">
            <div className="titulo">
            <h1 className="log">Login</h1>
            </div>
            <div className="dados">
            <h2>Vamos assistir um filme!</h2>
            <p>E-mail:</p><input type="text" name="email" id="email" onChange={this.mudarEstadoEmail} ></input><br></br>
            <p>Senha:</p><input type="text" name="senha" id="senha"  onChange={this.mudarEstadoSenha}></input><br></br>
            <button onClick = {this.efetuarLogin}>Entrar</button>
            </div>
            </div>
        );
    }
}
//erro na rota para a pagina de login 