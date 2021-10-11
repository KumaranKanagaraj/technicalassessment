import React, { useState, useEffect, Fragment } from 'react';
import moment from 'moment'
import { useParams } from 'react-router-dom';


const DetailTable = () => {
	const { Id } = useParams();
	const [asset, setAsset] = useState();

	useEffect(() => {
		fetch(`/api/${Id}/asset`)
			.then(results => results.json())
			.then(data => {
				setAsset(data);
			});
	}, []);

	const renderTableHeader = () => {
		if (!asset) {
			return <Fragment></Fragment>
		} else {
			const tableHeader = Object.keys(asset).filter(function (key) {
				return key !== 'Id';
			});
			return tableHeader.map((key, index) => {
				return <th key={index}>{key}</th>
			});
		}

	}

	const renderTableBody = () => {
		if (!asset) {
			return <React.Fragment></React.Fragment>
		}
		const { Id, FileName, MimeType, CreatedBy, Email, Country, Description, CreatedOn } = asset
		return (
			<tr key={Id}>
				<td>{FileName}</td>
				<td>{MimeType}</td>
				<td>{CreatedBy}</td>
				<td>{Email}</td>
				<td>{Country}</td>
				<td>{Description}</td>
				<td>{moment(CreatedOn).format("MMM Do YYYY")}</td>
			</tr>
		)
	}

	return (asset ? <React.Fragment>
		<h1>Asset Detail</h1>
		<table className="styled-table">
			<thead>
				<tr>{renderTableHeader()}</tr>
			</thead>
			<tbody>
				{renderTableBody()}
			</tbody>
		</table>
	</React.Fragment> : <div className="loader">Loading...</div>
	);
};

const Detail = () => (
	<DetailTable></DetailTable>
);

export default Detail