import {Map, InfoWindow, Marker, GoogleApiWrapper} from 'google-maps-react';
import React, {Component} from 'react';

export class MapContainer extends React.Component {
    constructor( ){
        super ();
        this.state = {
            showingInfoWindow: false,
            activeMarker: {},
            selectedPlace: {},
            listaMapa: []
        }

    }

    componentDidMount (event) {
        this.listarMapa()
    }

    listarMapa = () =>{
        fetch('http://192.168.5.84:5000/api/Localizacao')
            .then(response => response.json())
            .then(data => this.setState({listaMapa: data}))   
            // .then(data => this.console.log(data)) 
            .catch (erro=> console.log(erro))
    }

    displayMarkers = () => {
        return this.state.listaMapa.map((store, index) => {
        return <Marker key={index} id={index} position={{
                        lat: store.latitude,
                        lng: store.longitude
                    }} onClick={()=> console.log(store)} />
            })
            }
   
    render() {
      return (
//         <Map google={this.props.google}
//             onClick={this.onMapClicked}>
//    {this.state.listaMapa.map(x=>{
//          <Marker
//     title={'The marker`s title will appear as a tooltip.'}
//     name={'SOMA'}
//     position={{lat: x.latitude, lng: x.longitude}} />

//    })}
//           <InfoWindow
//             >
//           </InfoWindow>
//         </Map>
<div>
<h3
    style={{  color: "black", textAlign: "center",  fontFamily: "Fredoka One, cursive", fontSize: "30px"}}
    Localizações/>
<Map google={this.props.google} zoom={5}
  center= {(-13.6632305, -69.6410913)}
   style={mapStyles}
    initialCenter={{ lat: -8.5464085, lng: -53.4404716 }}
    >
    {this.displayMarkers()}
</Map>
</div>

      )
    }
  }

  export default GoogleApiWrapper({

  })(MapContainer)
 

const mapStyles = {
width: '100%',
height: '100%',


   };