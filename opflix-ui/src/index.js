import { Route, Link, BrowserRouter as Router, Switch, Redirect } from "react-router-dom";
import * as serviceWorker from './serviceWorker';
import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

//pages
import App from './Home/App'
import Login from './Login/login';
import homeA from './Administrador/homeA';
import cadastro from './Cadastro/cadastro';
import categorias from './Categorias/categorias';
import listar from './ListaL/listar';
import cadastrarCat from './CategoriaC/cadastrarCat';
import mapa from './Mapa/mapa';

//routes

const RotaPrivada = ({component: Component}) => (
    <Route
        render={ props =>
            localStorage.getItem("usuario-opflix") !== null ?
            (
                <Component {...props}/>
            ) : (
                <Redirect
                    to={{pathname: "/login", state: {from: props.location}}}
                />
            )
        }
    />
) 

const routing =(
    <Router>
        <div>
            <Switch>
                
                <Route exact path='/' component={App} />

                <Route path ='/login' component={Login} />

                <RotaPrivada path='/homeA' component={homeA} /> 

                <Route path='/cadastro' component={cadastro} /> 

                <Route path='/listar' component={listar} /> 

                <Route path='/cadastrarCat' component={cadastrarCat} /> 

                <Route path='/mapa' component= {mapa}></Route>

                <RotaPrivada  path='/categorias' component= {categorias}/>   


                </Switch>
        </div>
    </Router>
);


ReactDOM.render(routing, document.getElementById('root'));


// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
