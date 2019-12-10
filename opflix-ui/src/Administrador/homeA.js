import React, {Component} from "react";
import './homeA.css';


export default class homeA extends Component {

direcionar = (event) => {
    this.props.history.push('/cadastro')
}

irPara = (event) => {
    this.props.history.push('/listar')
}

cadastrar = (event) => {
    this.props.history.push('/cadastrarCat')
}

listar = (event) => {
    this.props.history.push('/categorias')
}

mapa = (event) => {
    this.props.history.push('/mapa')
}

render(){
    return(
        <div className="homeA">
        <h1>ADMINISTRADOR</h1>
        <h2>Lançamentos</h2>

        <div className="ce">
        <button onClick = {this.direcionar}>Cadastrar</button>
        </div>

        <div className="li">
        <button onClick = {this.irPara}>Listar</button>
        </div>


        <h2>Categorias</h2>

        <div className="ce">
        <button onClick = {this.cadastrar}>Cadastrar</button>
        </div>

        <div className="li">
        <button onClick = {this.listar}>Listar</button>
        </div>


        <div className="mapa">
        <button onClick = {this.mapa}>MAPA</button>
        </div>


        </div>

    );
}

}
