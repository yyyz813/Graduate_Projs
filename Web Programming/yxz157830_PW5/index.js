import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import App from './App';

class VideoGenreRow extends React.Component {
  render() {
    const genre = this.props.genre;
    return (
      <tr>
        <th colSpan="2">
          {genre}
        </th>
      </tr>
    );
  }
}

class VideoRow extends React.Component {
  render() {
    const product = this.props.product;
    const title = product.avaiable ?
      product.title :
      <span style={{ color: 'red' }}>
        {product.title}
      </span>;

    return (
      <tr>
        <td>{title}</td>
        <td>{product.description}</td>
      </tr>
    );
  }
}

class VideoTable extends React.Component {
  render() {

    const filterText = this.props.filterText;
    const isAvaiable = this.props.isAvaiable;

    const rows = [];
    let lastCategory = null;

    this.props.videos.forEach((product) => {
      if (product.title.indexOf(filterText) === -1) {
        return;
      }
      if (isAvaiable && !product.avaiable) {
        return;
      }
      if (product.genre !== lastCategory) {
        rows.push(
          <VideoGenreRow
            genre={product.genre}
            key={product.genre} />
        );
      }
      rows.push(
        <VideoRow
          product={product}
          key={product.name} />
      );
      lastCategory = product.genre;
    });

    return (
      <table>
        <thead>
          <tr>
            <th>title</th>
            <th>description</th>
          </tr>
        </thead>
        <tbody>{rows}</tbody>
      </table>
    );
  }
}

class SearchBar extends React.Component {
  constructor(props) {
    super(props);
    this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
    this.handleAvaliableChange = this.handleAvaliableChange.bind(this);
  }

  handleFilterTextChange(e) {
    this.props.onFilterTextChange(e.target.value);
  }

  handleAvaliableChange(e) {
    this.props.onAvaliableChange(e.target.checked);
  }

  render() {
    return (
      <form>
        <input type="text" placeholder="Search..." value={this.props.filterText} onChange={this.handleFilterTextChange} />
        <p>
          <input type="checkbox" checked={this.props.isAvaiable} onChange={this.handleAvaliableChange} />
          {' '}
          Only show movies is avaiable
        </p>
      </form>
    );
  }
}

class FilterableVideoTable extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      filterText: '',
      isAvaiable: false
    };
    this.handleFilterTextChange = this.handleFilterTextChange.bind(this);
    this.handleAvaliableChange = this.handleAvaliableChange.bind(this);
  }

  handleFilterTextChange(filterText) {
    this.setState({
      filterText: filterText
    });
  }
  
  handleAvaliableChange(isAvaiable) {
    this.setState({
      isAvaiable: isAvaiable
    })
  }

  render() {
    return (
      <div>
        <SearchBar
          filterText={this.state.filterText}
          isAvaiable={this.state.isAvaiable}
          onFilterTextChange={this.handleFilterTextChange}
          onAvaliableChange={this.handleAvaliableChange}
        />

        <VideoTable videos={this.props.videos}
          filterText={this.state.filterText}
          isAvaiable={this.state.isAvaiable}
        />
      </div>
    );
  }
}

 
const VIDEOS = [
  { genre: 'SciFi', description: 'When John Connor, leader of the human resistance, sends Sgt. Kyle Reese back to 1984 to protect Sarah Connor and safeguard the future, an unexpected turn of events creates a fractured timeline.', avaiable: true, title: 'Terminator Genisys' },
  { genre: 'Fantasy', description: 'A meek hobbit of the Shire and eight companions set out on a journey to Mount Doom to destroy the One Ring and the dark lord Sauron.', avaiable: true, title: 'The Lord of the Rings' },
  { genre: 'Drama', description: 'NASA must devise a strategy to return Apollo 13 to Earth safely after the spacecraft undergoes massive internal damage putting the lives of the three astronauts on board in jeopardy.', avaiable: false, title: 'Apollo 13' },
];

ReactDOM.render(
  /*
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  */
  <FilterableVideoTable videos={VIDEOS} />,
  document.getElementById('root')
);


// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
//reportWebVitals();