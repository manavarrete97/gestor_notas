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
 public class DeleteNotaManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IDeleteNotaDAO> _deleteNotaDAOMock;
 private DeleteNotaManager _deleteNotaManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _deleteNotaDAOMock = new Mock<IDeleteNotaDAO>();
 _deleteNotaManager = new DeleteNotaManager(_postgresConnectionMock.Object, _deleteNotaDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task DeleteNotaAsync_ShouldReturnTrue_WhenSuccessful()
 {
 // Arrange
 var idNota =1;
 var idProfesor =2;
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _deleteNotaDAOMock.Setup(p => p.ValidateProfesorForMateriaAsync(It.IsAny<NpgsqlConnection>(), idProfesor, idNota)).ReturnsAsync(true);
 _deleteNotaDAOMock.Setup(p => p.DeleteNotaAsync(It.IsAny<NpgsqlConnection>(), idNota, idProfesor)).ReturnsAsync(true);

 // Act
 var result = await _deleteNotaManager.DeleteNotaAsync(idNota, idProfesor);

 // Assert
 Assert.That(result, Is.True);
 }

 [Test]
 public void DeleteNotaAsync_ShouldThrowException_WhenProfesorNotAuthorized()
 {
 // Arrange
 var idNota =1;
 var idProfesor =2;
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _deleteNotaDAOMock.Setup(p => p.ValidateProfesorForMateriaAsync(It.IsAny<NpgsqlConnection>(), idProfesor, idNota)).ReturnsAsync(false);

 // Act & Assert
 Assert.ThrowsAsync<Exception>(async () => await _deleteNotaManager.DeleteNotaAsync(idNota, idProfesor), "El profesor no está autorizado para esta materia.");
 }
 }
}