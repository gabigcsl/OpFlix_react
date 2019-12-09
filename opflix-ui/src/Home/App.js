import React from 'react';
import './App.css';
import { Link } from "react-router-dom"; //import para direcionar o link para outra pagina



function App() {
  return (
    <div className="App">
      <div className="caixa">
        <div className="caixa">
          <h1>OPFLIX </h1>
          <div className="botao">
            <Link className="App" to="/login">Login</Link>
            {/* <button id="logar">Login</button> */}
          </div>
          </div>
            <button id="cadastro">Cadastrar</button>
        </div>
      </div>
      );
    }
    
    export default App;
