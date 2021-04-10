import React from 'react';
import Software from './software';

const SoftwareList = (props) => {  
  return (

    <div> 
      {
        props.softwareList.map(software => (
          <Software key={software.name + ':' + software.version} software={software} />
        ))
      }
    </div>
  )
};

export default SoftwareList