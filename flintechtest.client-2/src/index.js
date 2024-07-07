import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import './index.css';
import CatApp from './CatApp';
import ClubMemberBillEvaluation from './ClubMemberBillEvaluation';
import reportWebVitals from './reportWebVitals';
import '@progress/kendo-theme-default/dist/all.css';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <Router>
      <div>
        <nav>
          <ul>
            <li>
              <Link to="/">Cat API</Link>
            </li>
            <li>
              <Link to="/club-member-bill">Club Member Bill Evaluation</Link>
            </li>
          </ul>
        </nav>

        <Routes>
          <Route path="/" element={<CatApp />} />
          <Route path="/club-member-bill" element={<ClubMemberBillEvaluation />} />
        </Routes>
      </div>
    </Router>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
