import React, {Component} from "react";
import './cadastrarCat.css';
import Axios from 'axios';

export default class cadastrarCat extends Component{
    constructor(){
        super ()
        this.state = {
            nome: ""
        }
    }

    direcionar = (event) => {
        this.props.history.push('/homeA')
    }


    mudarEstadoNome = (event) => {
        this.setState({nome: event.target.value})
    }

    cadastrar = (event) => {
        Axios.defaults.headers.common['Authorization'] = 'Bearer'+localStorage.getItem("usuario-opflix");
        Axios.post("http://192.168.5.84:5000/api/categoria", {
            nome: this.state.nome
        })
        .then (data =>{
            if(data.status === 200){
                this.props.history.push('/homeA')
            }else{
                console.log("errou");
            }
        })
        .catch(erro =>{
            this.setState({erro: "campos vazios"});
            console.log(erro);
        })

    }

    render(){
        return(
            <div>
                <h1 className="cadastrar">Cadastrar</h1>
                <div className="voltar">
        <button onClick = {this.direcionar}>Voltar</button>
        </div>
                <div className="formulario">
                    <p>Nome da categoria:</p><input type="text" name="nome" id="nome" onChange={this.mudarEstadoNome}></input>
                </div>
                <button onClick ={this.cadastrar}>Cadastrar</button>
            </div>
        );
    }

}

///cadastrar categoria