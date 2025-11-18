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
 public class DeleteEstudianteManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IDeleteEstudianteDAO> _deleteEstudianteDAOMock;
 private DeleteEstudianteManager _deleteEstudianteManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _deleteEstudianteDAOMock = new Mock<IDeleteEstudianteDAO>();
 _deleteEstudianteManager = new DeleteEstudianteManager(_postgresConnectionMock.Object, _deleteEstudianteDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task DeleteEstudianteAsync_ShouldReturnTrue_WhenSuccessful()
 {
 // Arrange
 var id =1;
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _deleteEstudianteDAOMock.Setup(p => p.DeleteEstudianteAsync(It.IsAny<NpgsqlConnection>(), id)).ReturnsAsync(true);

 // Act
 var result = await _deleteEstudianteManager.DeleteEstudianteAsync(id);

 // Assert
 Assert.That(result, Is.True);
 }

 [Test]
 public async Task DeleteEstudianteAsync_ShouldReturnFalse_WhenFails()
 {
 // Arrange
 var id =1;
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _deleteEstudianteDAOMock.Setup(p => p.DeleteEstudianteAsync(It.IsAny<NpgsqlConnection>(), id)).ReturnsAsync(false);

 // Act
 var result = await _deleteEstudianteManager.DeleteEstudianteAsync(id);

 // Assert
 Assert.That(result, Is.False);
 }
 }
}