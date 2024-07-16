import './ShakespearePoem.css';

function ShakespearePoem(props) {
  const { title, poem } = props;
  return (
    <div className="shakespeare-poem">
      <h3>{title}</h3>
      <p>{poem}</p>
    </div>
  );
};

export default ShakespearePoem;
