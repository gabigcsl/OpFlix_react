import React, {Component} from "react";
import './categorias.css';
import Axios from 'axios';


export default class categorias extends Component {

    constructor (){
        super();
        this.state = {
            lista:[]
        }
    }

    direcionar = (event) => {
        this.props.history.push('/homeA')
    }

    componentDidMount = (event) => {
        this.props.history.push('/categorias')
        this.listarCategoria();
        console.log(this.state.lista)
    }

    listarCategoria = () =>{
        fetch('http://192.168.5.84:5000/api/categoria')
            .then(response => response.json())
            .then(data => this.setState({lista: data}))   
            // .then(data => this.console.log(data)) 
            .catch (erro=> console.log(erro))
    }

    render(){
        return(
<tr>

                <h1 className="categorias">CATEGORIAS</h1>

        <div className="voltar">
        <button onClick = {this.direcionar}>Voltar</button>
        </div>
                
        <tbody className='lista'>
            {this.state.lista.map(element =>{
                return(

                    <tr key={element.idCategoria}>
                    <td >{element.nome}</td>
                </tr>
                    );
            })}
        </tbody>

</tr>

        );
    }
    
}
