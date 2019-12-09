import React, {Component} from "react";
import './cadastro.css';
import Axios from 'axios';


export default class cadastro extends Component {

    constructor (){
        super();
        this.state = {
            titulo:"",
            tipo:"",
            duracao:"",
            data:"",
            plataforma:"",
            sinopse:"",
            erro:""

        }
    }

    
    voltar = (event) => {
        this.props.history.push('/homeA')
    }

    mudarEstadoNome = (event) =>{
        this.setState({nome: event.target.value})
    }

    mudarEstadoTipo = (event) =>{
        this.setState({tipo: event.target.value})
    }

    mudarEstadoCategoria = (event) =>{
        this.setState({idCategoria: event.target.value})
    }

    mudarEstadoDuracao = (event) =>{
        this.setState({duracao: event.target.value})
    }

    mudarEstadoData = (event) =>{
        this.setState({data: event.target.value})
    }

    mudarEstadoPlataforma = (event) =>{
        this.setState({plataforma: event.target.value})
    }

    mudarEstadoSinopse = (event) =>{
        this.setState({sinopse: event.target.value})
    }

    direcionar = (event) => {
        Axios.defaults.headers.common['Authorization'] = 'Bearer '+localStorage.getItem("usuario-opflix");
            Axios.post("http://192.168.5.84:5000/api/Lancamento",{
                nome: this.state.nome,
                tipo: this.state.tipo,
                idCategoria:this.state.idCategoria,
                duracao: this.state.duracao,
                data: this.state.data,
                plataforma: this.state.plataforma,
                sinopse: this.state.sinopse

            })
             .then (data =>{
                 if(data.status === 200){
                     
                     this.props.history.push('/categorias');
                 }else{
                     console.log("errou");
                 }
             })
             .catch(erro =>{
                this.setState({erro: "campos vazios"});
                console.log(erro);
             })
        
    }

    render() {
        return(
            <div>
            <h1 className="cadastro">Cadastrar</h1>
            <div className="formulario">

            <div className="voltar">
        <button onClick = {this.voltar}>Voltar</button>
        </div>

            <p>Título:</p><input type="text" name="titulo" id="titulo" onChange={this.mudarEstadoNome} ></input><br></br>
            <p>Tipo(série/filme/etc.):</p><input type="text" name="tipo" id="tipo" onChange={this.mudarEstadoTipo} ></input><br></br>
            <p>Categoria:</p><input type="int" name="categoria" id="categoria" onChange={this.mudarEstadoCategoria} ></input><br></br>
            <p>Duração:</p><input type="text" name="duracao" id="duracao" onChange={this.mudarEstadoDuracao} ></input><br></br>
            <p>Data de Lançamento:</p><input type="date" name="data" id="data" onChange={this.mudarEstadoData} ></input><br></br>
            <p>Plataforma:</p><input type="text" name="plataforma" id="plataforma" onChange={this.mudarEstadoPlataforma} ></input><br></br>
            <p>Sinopse:</p><input type="text" name="sinopse" id="sinopse" onChange={this.mudarEstadoSinopse} ></input><br></br>
            </div>

            <div>
            <button onClick = {this.direcionar}>Cadastrar</button>
            </div>

            </div>

        );
    }

}
