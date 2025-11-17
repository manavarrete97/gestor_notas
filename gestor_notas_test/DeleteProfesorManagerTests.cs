using gestor_notas.Manager;
using gestor_notas.DAO.Interface;
using gestor_notas.Common.Interface;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas_test
{
 [TestFixture]
 public class DeleteProfesorManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IDeleteProfesorDAO> _deleteProfesorDAOMock;
 private DeleteProfesorManager _deleteProfesorManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _deleteProfesorDAOMock = new Mock<IDeleteProfesorDAO>();
 _deleteProfesorManager = new DeleteProfesorManager(_postgresConnectionMock.Object, _deleteProfesorDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task DeleteProfesorAsync_ShouldReturnTrue_WhenDAOOperationSucceeds()
 {
 // Arrange
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _deleteProfesorDAOMock.Setup(p => p.DeleteProfesorAsync(It.IsAny<NpgsqlConnection>(),1)).ReturnsAsync(true);

 // Act
 var result = await _deleteProfesorManager.DeleteProfesorAsync(1);

 // Assert
 Assert.That(result, Is.True);
 }

 [Test]
 public async Task DeleteProfesorAsync_ShouldReturnFalse_WhenDAOOperationFails()
 {
 // Arrange
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _deleteProfesorDAOMock.Setup(p => p.DeleteProfesorAsync(It.IsAny<NpgsqlConnection>(),1)).ReturnsAsync(false);

 // Act
 var result = await _deleteProfesorManager.DeleteProfesorAsync(1);

 // Assert
 Assert.That(result, Is.False);
 }
 }
}