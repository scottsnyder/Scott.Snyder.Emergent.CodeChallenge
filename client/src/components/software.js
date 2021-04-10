import React from 'react'

const Software = (props) => {   

    return (
        <div>
            {   
            <div className="card">
                <div className="card-body">
                    <h5 className="card-title">Name:&nbsp;{props.software.name}</h5>
                    <h6 className="card-subtitle mb-2 text-muted">
                        Version:&nbsp;{props.software.version}
                    </h6>
                </div>
            </div>
            }
        </div>
    )
};

export default Software