import React, { useState, useEffect, Fragment } from 'react';
import moment from 'moment'
import { useHistory } from 'react-router-dom';


const AssetTable = () => {
	const [assets, setAssets] = useState([]);
	const [page, setPage] = useState(1);
	const [limit, setLimit] = useState(10);
	const history = useHistory();

	useEffect(() => {
		fetch(`/api/assets?page=${page}&limit=${limit}`)
			.then(results => results.json())
			.then(data => {
				setAssets(data);
			});
	}, [page, limit]);

	const handleClick = (Id) => history.push('/asset/' + Id);

	const renderTableHeader = () => {
		if (assets.length == 0) {
			return <Fragment></Fragment>
		} else {
			const tableHeader = Object.keys(assets[0]).filter(function (key) {
				return key !== 'Id';
			});
			return tableHeader.map((key, index) => {
				return <th key={index}>{key}</th>
			});
		}

	}

	const renderTableBody = () => {
		return assets.map((asset, index) => {
			const { Id, FileName, CreatedOn } = asset
			return (
				<tr key={Id} onClick={() => handleClick(Id)}>
					<td>{FileName}</td>
					<td>{moment(CreatedOn).format("MMM Do YYYY")}</td>
				</tr>
			)
		})
	}

	const onNext = () => {
		setPage(page + 1);
	};

	const onPrevious = () => {
		if (page != 0) {
			setPage(page - 1);
		}
	};

	return (assets.length > 0 ? <React.Fragment>
		<h1>Asset Summary</h1>
		<table className="styled-table">
			<thead>
				<tr>{renderTableHeader()}</tr>
			</thead>
			<tbody>
				{renderTableBody()}
			</tbody>
		</table>
		<div className="pagination-container">
			<button onClick={onPrevious} className="previous">&laquo; Previous</button>
			<button onClick={onNext} className="next">Next &raquo;</button>
		</div>
	</React.Fragment> : <div className="loader">Loading...</div>
	);
};

const Index = () => (
	<AssetTable />
);

export default Index